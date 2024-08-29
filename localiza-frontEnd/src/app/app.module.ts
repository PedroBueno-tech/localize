import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { ClientesComponent } from './clientes/clientes.component';
import { CobrancasComponent } from './clientes/cobrancas/cobrancas.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatDialogModule} from '@angular/material/dialog';
import { NotFoundComponent } from './modal/not-found/not-found.component';
import { CreatedComponent } from './modal/created/created.component';
import { NewClientComponent } from './modal/new-client/new-client.component';
import { EditClientComponent } from './modal/edit-client/edit-client.component';
import { DeleteSucessComponent } from './modal/delete-sucess/delete-sucess.component';
import { NewCobrancaComponent } from './modal/new-cobranca/new-cobranca.component';
import { EditCobrancaComponent } from './modal/edit-cobranca/edit-cobranca.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CadastroComponent,
    ClientesComponent,
    CobrancasComponent,
    NotFoundComponent,
    CreatedComponent,
    NewClientComponent,
    EditClientComponent,
    DeleteSucessComponent,
    NewCobrancaComponent,
    EditCobrancaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule
  ],
  providers: [
    provideClientHydration(),
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
