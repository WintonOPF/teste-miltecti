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
    tipoAnuncio: ['', Validators.required],
    nomeAnuncio: ['', Validators.required],
    dataPublicacao: ['', Validators.required],
    valor: ['', [Validators.required]],
    cidade: ['', Validators.required],
    categoria: [{ value: '', disabled: true }, Validators.required],
    modelo: [{ value: '', disabled: true }, Validators.required],
    condicao: [{ value: '', disabled: true }, Validators.required],
    quantidade: [{ value: '', disabled: true }, [Validators.required]],
    tipoServico: [{ value: '', disabled: true }, Validators.required],
    });

    
  }

  ngOnInit(): void {
    this.carregarAnuncios();
  }

  carregarAnuncios() {
    this.anuncioService.getAnuncios().subscribe(
      (data) => {
        this.anuncios= data;
        console.log('Anúncios carregados:', data);
      },
      (error) => {
        console.error('Erro ao carregar anúncios:', error);
      }
    );
  }

  limparFormulario(): void {
    this.anuncioForm.reset();
    this.isProduto = false;
    this.isServico = false;
    alert('Formulário limpo com sucesso!');
  }

  criarAnuncio() {
    if (this.anuncioForm.valid) {
      const novoAnuncio: Anuncio = this.anuncioForm.value;
      this.anuncioService.createAnuncio(novoAnuncio).subscribe(
        (response) => {    
          alert('Anúncio criado com sucesso!');
          this.carregarAnuncios();
          this.anuncioForm.reset();
        },
        (error) => { 
          const errors: { [key: string]: string } = error.error.errors;       
          this.processApiErrors(errors);
          
        }
      );
    } else {
      alert('Formulário inválido! Verifique os campos.');
    }
  }

  private processApiErrors(errors: { [key: string]: string }): void {
    
    Object.keys(errors).forEach((field) => {
      const control = this.anuncioForm.get(field);
      if (control) {
        control.setErrors({ apiError: errors[field] });
      }
    });
  }

isProduto = false;
isServico = false;

onTipoAnuncioChange(): void {
  const tipoAnuncio = this.anuncioForm.get('tipoAnuncio')?.value;
  this.isProduto = tipoAnuncio === 'Produto';
  this.isServico = tipoAnuncio === 'Serviço';

  if (this.isProduto) {
    this.enableProdutoFields();
    this.disableServicoFields();
  } else if (this.isServico) {
    this.enableServicoFields();
    this.disableProdutoFields();
  }
}

enableProdutoFields(): void {
  ['categoria', 'modelo', 'condicao', 'quantidade'].forEach((field) => {
    this.anuncioForm.get(field)?.enable();
  });
}

disableProdutoFields(): void {
  ['categoria', 'modelo', 'condicao', 'quantidade'].forEach((field) => {
    this.anuncioForm.get(field)?.disable();
  });
}

enableServicoFields(): void {
  this.anuncioForm.get('tipoServico')?.enable();
}

disableServicoFields(): void {
  this.anuncioForm.get('tipoServico')?.disable();
}

}
