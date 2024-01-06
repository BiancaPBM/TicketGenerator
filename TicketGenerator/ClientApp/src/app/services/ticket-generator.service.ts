import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Ticket } from "../models/ticket.model";
import { Observable } from "rxjs";
import { TicketBox } from "../models/ticket-box.model";
import { API_URL } from "../variables-injection";

@Injectable({
  providedIn: 'root',
})

export class TicketGeneratorService {
  private readonly defaultHttpOptions = {
    headers: new HttpHeaders({
      'Content-type': 'application/json',
      'Accept': 'application/json'
    })
  }
  private api: string;
  constructor(private httpClient: HttpClient, @Inject("BASE_URL") apiUrl: string) {
    this.api = apiUrl;
}

  getTickets(): Observable<Ticket[]> {
    return this.httpClient.get<Ticket[]>( this.api + "api/tickets", this.defaultHttpOptions);
  }

  getTicketById(ticketId:number): Observable<TicketBox> {
    return this.httpClient.get<TicketBox>(this.api + `api/tickets/${ticketId}`, this.defaultHttpOptions);
  }

  createTicket(ticketBox: TicketBox) {
    return this.httpClient.post(this.api + "api/tickets", ticketBox, this.defaultHttpOptions); 
  }
}
