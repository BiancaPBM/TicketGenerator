import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { API_URL } from './variables-injection';
import { environment } from '../environments/environment';
import { TicketGeneratorComponent } from './components/ticket-generator/ticket-generator.component';

@NgModule({
  declarations: [
    AppComponent,
    TicketGeneratorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: TicketGeneratorComponent, pathMatch: 'full' }
    ])
  ],
  providers: [
    {
      provide: API_URL,
      useValue: environment.API
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
