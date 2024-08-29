import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {

   private apiUrl= 'https://localhost:7102/api/Usuario/'

  constructor(private http: HttpClient) { }

  cadastrar(nome: string, email: string, senha: string){
    const data = {nome, email, senha}
    return this.http.post<any>(this.apiUrl, data);
  }
}
