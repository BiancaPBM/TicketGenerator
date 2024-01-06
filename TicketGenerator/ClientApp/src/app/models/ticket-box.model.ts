import { Box } from "./box.model";

export class TicketBox {
  name: string;
  boxes: Box[];
  superzahl: number | null;
  constructor(name: string | null, boxes: Box[], superzahl: number | null) {
    this.name = name != null ? name : 'No title provided';
    this.boxes = boxes;
    this.superzahl = superzahl;
  }
}
