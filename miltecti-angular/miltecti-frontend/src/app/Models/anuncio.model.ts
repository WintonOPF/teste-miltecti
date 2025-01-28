export interface Anuncio {
    id: number;
    nomeAnuncio: string;
    dataPublicacao: string;
    valor: number;
    cidade: string;
    categoria?: string;  
    modelo?: string;     
    condicao?: string;   
    quantidade?: number; 
    tipoServico?: string; 
    tipoAnuncio: string; 
  }
  