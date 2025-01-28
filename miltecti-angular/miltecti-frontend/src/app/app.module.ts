import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component'; 
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { AnuncioComponent } from './anuncio/anuncio.component';
import { HttpClient } from '@angular/common/http';
 

@NgModule({
  declarations: [
    AppComponent,
    AnuncioComponent,
  ], 
  imports: [
    BrowserModule,
    CommonModule,
    AppComponent,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule ,
    HttpClient,
  ],
  providers: [],
  bootstrap: [AppComponent], 
})
export class AppModule {}
