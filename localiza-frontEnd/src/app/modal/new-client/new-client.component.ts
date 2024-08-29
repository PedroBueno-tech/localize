import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ClientesService } from '../../clientes/clientes.service';
import { Router } from '@angular/router';
import { CreatedComponent } from '../created/created.component';

@Component({
  selector: 'app-new-client',
  templateUrl: './new-client.component.html',
  styleUrl: './new-client.component.css'
})
export class NewClientComponent {
  constructor(private dialog: MatDialog, private service: ClientesService, private router: Router){}

  nome: string = '';
  documento: string = '';
  telefone: string = '';
  endereco: string = '';
  usuarioId: string = '';


  cadastrarCliente(){

    const userData = JSON.parse(localStorage.getItem('userData') || '{}');
    this.usuarioId = userData.id;
    if(this.nome == null || this.nome == '' || this.documento == null || this.documento == '' || this.telefone == null || this.telefone == '' || this.endereco == null || this.endereco == ''){
      alert("campos vazios")
    } else if(userData == null || userData == '' ){
      alert("nao logado")
    } else {
      try{
        this.service.cadastrarCliente(this.nome,this.documento, this.telefone, this.endereco, this.usuarioId).subscribe(
          (response) => {
            if(response == null){
              alert('Houve um erro ao cadastrar novo usuário');
            } else {
              this.dialog.open(CreatedComponent)
              window.location.reload();
            }
          }
        )
      } catch(e){
      }
    }
  }

}
