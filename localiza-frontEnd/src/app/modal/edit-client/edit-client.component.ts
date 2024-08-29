import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../../clientes/clientes.service';
import { CreatedComponent } from '../created/created.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-client',
  templateUrl: './edit-client.component.html',
  styleUrl: './edit-client.component.css'
})
export class EditClientComponent implements OnInit {

  id: string = '';
  nome:string = '' ;
  documento: string = '' ;
  telefone: string = '' ;
  endereco: string = '' ;
  userId: string = '' ;

  constructor(private service: ClientesService, private router: Router, private dialog: MatDialog){}

  ngOnInit(): void {
    const clienteData = JSON.parse(localStorage.getItem('clienteData') || '{}');
    this.id = clienteData.id;
    this.nome = clienteData.nome;
    this.documento = clienteData.documento;
    this.telefone = clienteData.telefone;
    this.endereco = clienteData.endereco;
    this.userId = clienteData.usuarioId;
  }
  updateCliente(){
    if(this.nome == null || this.nome == '' || this.documento == null || this.documento == '' || this.telefone == null || this.telefone == '' || this.endereco == null || this.endereco == ''){
      alert("campos vazios")
    } else if(this.userId == null || this.userId == '' ){
      alert("nao logado")
    } else {
        this.service.updateCliente(this.id ,this.nome,this.documento, this.telefone, this.endereco, this.userId).subscribe(
          (response) => {
            if(response == null){
              alert('Houve um erro ao cadastrar novo usuário');
            } else {
              this.dialog.open(CreatedComponent)
              window.location.reload();
            }
          }
        )
    }
  }

}
