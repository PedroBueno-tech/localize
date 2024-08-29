import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private apiUrl= 'https://localhost:7102/api/Usuario/login'

  constructor(private http: HttpClient) { }

  login(Email: string, Senha: string): Observable<any>{
    const data = {Email, Senha}
    return this.http.post<any>(this.apiUrl, data);
  }
}
