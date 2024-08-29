import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { CobrancasService } from './cobrancas.service';
import { NewCobrancaComponent } from '../../modal/new-cobranca/new-cobranca.component';
import { MatDialog } from '@angular/material/dialog';
import { EditCobrancaComponent } from '../../modal/edit-cobranca/edit-cobranca.component';
import { DeleteSucessComponent } from '../../modal/delete-sucess/delete-sucess.component';
import { NotFoundComponent } from '../../modal/not-found/not-found.component';

@Component({
  selector: 'cobrancas',
  templateUrl: './cobrancas.component.html',
  styleUrl: './cobrancas.component.css'
})
export class CobrancasComponent implements OnInit{

  cliente:any;
  cobrancas: any;

  constructor(private route: ActivatedRoute, private router: Router, private service: CobrancasService, private dialog: MatDialog){}


  ngOnInit() {
    this.showCobrancas()
  }

  showCobrancas() {
    const clienteData = JSON.parse(localStorage.getItem('clienteData') || '{}');
    this.cliente = clienteData;

    if (clienteData != null) {
      this.service.showCobrancas(clienteData.id).subscribe(
        (response) => {
          if (Array.isArray(response)) {
            this.cobrancas = response.map(cobranca => {
              if(cobranca.isPago === false && new Date(cobranca.dataVencimento) < new Date()){
                cobranca.atrasado = true
              }

              if (cobranca.dataVencimento) {
                cobranca.dataVencimento = new Date(cobranca.dataVencimento).toISOString().split('T')[0];
              }
              return cobranca;
            });
          } else {
            this.cobrancas = response;
          }
        }
      );
    }
  }
  voltarPagina(){
    this.router.navigate(['/clientes']);
  }

  cadastrarNovo(){
    this.dialog.open(NewCobrancaComponent)
  }

  updateCobranca(updateCobranca: any){
    localStorage.setItem('cobrancaData', JSON.stringify(updateCobranca));
    this.dialog.open(EditCobrancaComponent)
  }

  deletarCobranca(id: any){
    this.service.deletarCobranca(id).subscribe(
      (response) => {
        if(response = true){
          this.dialog.open(DeleteSucessComponent)
        } else {
          this.dialog.open(NotFoundComponent)
        }
      }
    )
    window.location.reload();
  }

}
