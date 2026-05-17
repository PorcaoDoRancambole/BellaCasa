import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriaService } from './categoria.service';
import { Categoria } from './categoria.model';

@Component({
  selector: 'categoria-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './categoria-form.component.html',
  styleUrls: ['./categoria-form.component.css']
})
export class CategoriaFormComponent {
  categoria: Categoria = { nome: '', descricao: '' };
  loading = false;
  error?: string;
  isEdit = false;

  constructor(
    private service: CategoriaService,
    private route: ActivatedRoute,
    public router: Router
  ) {
    const idParam = this.route.snapshot.paramMap.get('id');
    const id = idParam ? Number(idParam) : null;
    if (id) {
      this.isEdit = true;
      this.loading = true;
      this.service.buscar(id).subscribe({
        next: (c) => { this.categoria = c; this.loading = false; },
        error: (err) => { this.error = err?.message ?? 'Erro'; this.loading = false; }
      });
    }
  }

  submit() {
    this.loading = true;
    this.error = undefined;
    const op = this.isEdit && this.categoria.id
      ? this.service.atualizar(this.categoria.id, this.categoria)
      : this.service.salvar(this.categoria);

    op.subscribe({
      next: () => this.router.navigate(['/categorias']),
      error: (err) => { this.error = err?.message ?? 'Erro'; this.loading = false; }
    });
  }
}
