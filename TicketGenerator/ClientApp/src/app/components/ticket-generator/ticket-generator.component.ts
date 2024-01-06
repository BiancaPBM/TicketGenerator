import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, Validators } from "@angular/forms";
import { Ticket } from "../../models/ticket.model";
import { TicketBox } from "../../models/ticket-box.model";
import { Box } from "../../models/box.model";
import { TicketGeneratorService } from "../../services/ticket-generator.service";

@Component({
  selector: 'ticket-generator',
  templateUrl: './ticket-generator.component.html',
  styleUrls: ['./ticket-generator.component.scss']
})
export class TicketGeneratorComponent implements OnInit {
  constructor(private ticketService: TicketGeneratorService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.ticketService.getTickets().subscribe(res => this.tickets = res);
  }

  numbers : number[] = new Array(49);
  boxNumber: number = 0;
  isLoading = false;
  form = this.formBuilder.group({
    boxes: new FormControl(null, Validators.required),
    name: new FormControl(null),
    hasSuperzahl: new FormControl(null)
  })
  displayTicket: TicketBox | undefined;
  tickets: Ticket[] = [];
  hasArrowsAvailable: boolean = false;

  generateTicket(n: any): void {
    if (n == null || n < 1 || n > 100) {
      this.isLoading = false;
      return;
    }
    this.isLoading = true;
    this.hasArrowsAvailable = false;
    this.boxNumber = 0;
    let boxes: Box[] = [];
    let interval = setInterval(() => {
      boxes.push(new Box(this.generateNumbers()));
      if (--n == 0) {
        let superZahl = null;
        clearInterval(interval);
        if (this.form.controls.hasSuperzahl.value) {
          superZahl = Math.floor(Math.random() * 9) + 1;
        }
        let ticket = new TicketBox(this.form.controls.name.value, boxes, superZahl);
        this.ticketService.createTicket(ticket).subscribe(res => {
          this.ticketService.getTickets().subscribe(res => {
            this.tickets = res;
            this.isLoading = false;
          });
        })
      }
    }, 1000)
  }

  generateNumbers(): number[] {
    var numbers = [];
    while (numbers.length < 6) {
      var random = Math.floor(Math.random() * 49) + 1;
      if (numbers.indexOf(random) == -1) {
        numbers.push(random);
      }
    }
    numbers.sort((a, b) => {
      return a - b;
    });
    const existingNumbers = new Set(numbers);
    this.colorNumbers(existingNumbers);
    return numbers;
  }

  colorNumbers(existingNumbers: any): void {
    var ball = document.getElementsByClassName("ball") as HTMLCollectionOf<HTMLElement>;
    for (var i = 0; i < ball.length; i++) {
      ball[i].style.backgroundColor = "white";
      ball[i].style.color = "#3d3c3a";
      ball[i].style.animation = "none";
      if (existingNumbers.has(parseInt(ball[i].innerHTML))) {
        ball[i].style.backgroundColor = "#0f5132";
        ball[i].style.transition= "background-color 0.5s ease";
        ball[i].style.color = "white";
      }
    }
  }

  displayNextBox(): void {
    if (this.displayTicket != null && this.boxNumber < this.displayTicket.boxes.length - 1) {
      this.boxNumber++;
      this.colorNumbers(this.getNumbers(this.displayTicket.boxes[this.boxNumber]));
    }
  }

  displayPreviousBox(): void {
    if (this.displayTicket != null && this.boxNumber > 0) {
      --this.boxNumber;
      this.colorNumbers(this.getNumbers(this.displayTicket.boxes[this.boxNumber]));
    }
  }

  getTicketById(id: number): void {
    this.ticketService.getTicketById(id).subscribe(res => {
      this.boxNumber = 0;
      this.displayTicket = new TicketBox(res.name, res.boxes, res.superzahl);
      this.colorNumbers(this.getNumbers(this.displayTicket.boxes[this.boxNumber]));
      this.hasArrowsAvailable = true;
    });
  }

  getNumbers(box: Box): Set<number> {
    return new Set([box.number1, box.number2, box.number3, box.number4, box.number5, box.number6]);
  }
}
