import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CobrancasService {

  private apiUrl= 'https://localhost:7102/api/Cobranca/'

  constructor(private http: HttpClient) { }

  showCobrancas(clienteId: number){
    return this.http.get(this.apiUrl + "getClient/" + String(clienteId));
  }

  cadastrarCobranca(descricao: any,valor: any, dataVencimento: any, isPago: any, clienteId: any){
    if(isPago == 'sim'){
      isPago = true;
    } else {
      isPago = false;
    }
    const data = {descricao, valor, dataVencimento, isPago, clienteId}
    return this.http.post(this.apiUrl, data)
  }

  updateCobranca(id: any, descricao: any,valor: any, dataVencimento: any, isPago: any, clienteId: any){
    if(isPago == 'sim'){
      isPago = true;
    } else {
      isPago = false;
    }
    const data = {descricao, valor, dataVencimento, isPago, clienteId}
    return this.http.put(this.apiUrl + id, data)
  }
  deletarCobranca(id: string){
    return this.http.delete(this.apiUrl + id)
  }

}
