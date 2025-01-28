import { Component } from '@angular/core';
import { AnuncioComponent } from './anuncio/anuncio.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [AnuncioComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'miltecti-frontend';
}
