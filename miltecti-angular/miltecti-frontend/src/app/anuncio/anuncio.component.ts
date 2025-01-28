import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AnuncioService } from '../Services/anuncio.service';
import { Anuncio } from '../Models/anuncio.model';

@Component({
  selector: 'app-anuncio',
  standalone: true,
  templateUrl: './anuncio.component.html',
  styleUrls: ['./anuncio.component.css'],
  imports: [CommonModule, ReactiveFormsModule, ],
})
export class AnuncioComponent implements OnInit {
  httpClient = inject(HttpClient);
  anuncioForm: FormGroup;
  anuncios: Anuncio[] = [];

  constructor(private fb: FormBuilder, private anuncioService: AnuncioService) {
    
    this.anuncioForm = this.fb.group({
      nomeAnuncio: ['', [Validators.required, Validators.minLength(5)]],
      dataPublicacao: ['', [Validators.required]],
      valor: [0, [Validators.required, Validators.min(1)]],
      cidade: ['', Validators.required],
      categoria: [''],
      modelo: [''],
      condicao: [''],
      quantidade: [0, [Validators.min(1)]],
      tipoServico: [''],
      tipoAnuncio: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.carregarAnuncios();
  }

  carregarAnuncios() {
    this.anuncioService.getAnuncios().subscribe(
      (data) => {
       
        console.log('Anúncios carregados:', data);
      },
      (error) => {
        console.error('Erro ao carregar anúncios:', error);
      }
    );
  }

  criarAnuncio() {
    if (this.anuncioForm.valid) {
      const novoAnuncio: Anuncio = this.anuncioForm.value;
      this.anuncioService.createAnuncio(novoAnuncio).subscribe(
        (response) => {
          console.log('Anúncio criado com sucesso:', response);
          alert('Anúncio criado com sucesso!');
          this.carregarAnuncios();
          this.anuncioForm.reset();
        },
        (error) => {
          console.error('Erro ao criar anúncio:', error);
          alert('Erro ao criar o anúncio.');
        }
      );
    } else {
      alert('Formulário inválido! Verifique os campos.');
    }
  }
}
