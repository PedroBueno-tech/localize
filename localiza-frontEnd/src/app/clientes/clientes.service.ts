import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  private apiUrl= 'https://localhost:7102/api/Cliente/'

  constructor(private http: HttpClient) { }

  showClientes(userId: number): Observable<any>{
    return this.http.get(this.apiUrl + "getUser/" + String(userId));
  }
  cadastrarCliente(nome: string, documento: string, telefone: string, endereco: string, usuarioId:string): Observable<any>{
    const data = {nome, documento, telefone, endereco, usuarioId}
    return this.http.post<any>(this.apiUrl, data);
  }

  updateCliente(id: string ,nome: string, documento: string, telefone: string, endereco: string, usuarioId:string){
    const data = {nome, documento, telefone, endereco, usuarioId}
    return this.http.put(this.apiUrl + id, data)
  }

  deleteCliente(id: string){
    return this.http.delete(this.apiUrl + id)
  }

}
