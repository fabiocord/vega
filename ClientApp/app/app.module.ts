import { PessoaFisicaFormValidatorService } from './components/pessoa-fisica-form/pessoa-fisica-form.validator';
import { PessoaFisicaService } from './services/pessoaFisica.service';
import { PessoaJuridicaFormValidatorService } from './components/pessoa-juridica-form/pessoa-juridica-form.validator';
import { PessoaJuridicaService } from './services/pessoaJuridica.service';
import { AdminComponent } from './components/admin/admin.component';
import { BrowserXhr } from '@angular/http';
import { BrowserXhrWithProgress, ProgressService } from './services/progress.service';
import { PaginationComponent } from './components/shared/pagination.component';
import * as Raven from 'raven-js'; 
import { FormsModule,ReactiveFormsModule } from '@angular/forms'; 
import { NgModule, ErrorHandler } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';
import { UniversalModule } from 'angular2-universal';
import { ChartModule } from 'angular2-chartjs';

import { AppComponent } from './components/app/app.component'
import { AppErrorHandler } from './app.error-handler';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { PessoaJuridicaFormComponent } from './components/pessoa-juridica-form/pessoa-juridica-form.component';
import { PessoaJuridicaListComponent } from './components/pessoa-juridica-list/pessoa-juridica-list.component';
import { InputMaskModule} from 'primeng/primeng';
import { BrowserModule } from '@angular/platform-browser';
import { EnderecoFormComponent } from './components/shared/endereco-form/endereco-form.component';
import { ControlMessageComponent } from './components/shared/control-message/control-message.component';
import { PessoaFisicaFormComponent } from './components/pessoa-fisica-form/pessoa-fisica-form.component';
import { PessoaFisicaListComponent } from './components/pessoa-fisica-list/pessoa-fisica-list.component';

Raven.config('https://d37bba0c459b46e0857e6e2b3aeff09b@sentry.io/155312').install();

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,        
        HomeComponent,        
        PaginationComponent,
        AdminComponent,
        PessoaJuridicaFormComponent,
        PessoaJuridicaListComponent,
        EnderecoFormComponent,
        ControlMessageComponent,
        PessoaFisicaFormComponent,
        PessoaFisicaListComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        ReactiveFormsModule,
        BrowserModule,        
        ToastyModule.forRoot(),
        ChartModule,        
        InputMaskModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'pessoasJuridicas', pathMatch: 'full' },
            { path: 'pessoasJuridicas', component: PessoaJuridicaListComponent},
            { path: 'pessoasJuridicas/new', component: PessoaJuridicaFormComponent},
            { path: 'pessoasJuridicas/:id/:cnpj', component: PessoaJuridicaFormComponent},
            { path: 'pessoasFisicas', component: PessoaFisicaListComponent},
            { path: 'pessoasFisicas/new', component: PessoaFisicaFormComponent},
            { path: 'pessoasFisicas/:id/:cpf', component: PessoaFisicaFormComponent},           
            { path: 'admin', component: AdminComponent},
            { path: 'home', component: HomeComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
      { provide: ErrorHandler, useClass: AppErrorHandler },
      { provide: 'IValidatorService', useClass:PessoaJuridicaFormValidatorService},
      { provide: 'IValidatorService', useClass:PessoaFisicaFormValidatorService},     
      PessoaJuridicaService,
      PessoaFisicaService,     
      PessoaJuridicaFormValidatorService,
      PessoaFisicaFormValidatorService
    ]
})
export class AppModule {
}
