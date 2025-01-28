export interface Anuncio {
    id: number;
    nomeAnuncio: string;
    dataPublicacao: string;
    valor: number;
    cidade: string;
    categoria?: string;  // Opcional para serviços
    modelo?: string;     // Opcional para serviços
    condicao?: string;   // Opcional para serviços
    quantidade?: number; // Opcional para serviços
    tipoServico?: string; // Opcional para produtos
    tipoAnuncio: string;  // 'Produto' ou 'Serviço'
  }
  