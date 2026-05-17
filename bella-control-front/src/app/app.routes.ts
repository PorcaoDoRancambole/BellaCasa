import { Routes } from '@angular/router';
import { CategoriaListComponent } from './categoria/categoria-list.component';
import { CategoriaFormComponent } from './categoria/categoria-form.component';
import { CategoriaDetailComponent } from './categoria/categoria-detail.component';

export const routes: Routes = [
	{ path: '', redirectTo: 'categorias', pathMatch: 'full' },
	{ path: 'categorias', component: CategoriaListComponent },
	{ path: 'categorias/novo', component: CategoriaFormComponent },
	{ path: 'categorias/editar/:id', component: CategoriaFormComponent },
	{ path: 'categorias/detalhes/:id', component: CategoriaDetailComponent },
	{ path: '**', redirectTo: 'categorias' }
];
