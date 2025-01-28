import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Anuncio } from '../Models/anuncio.model';

@Injectable({
  providedIn: 'root',
})
export class AnuncioService {
  private apiUrl = 'https://localhost:7135/api/Anuncio'; // URL base da API

  constructor(private http: HttpClient) {}

  getAnuncios(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  createAnuncio(anuncio: any): Observable<any> {
    return this.http.post<any[]>(`${this.apiUrl}/anuncio`, anuncio, { headers:{ 'Content-Type': 'application/json'} });
  }

}
