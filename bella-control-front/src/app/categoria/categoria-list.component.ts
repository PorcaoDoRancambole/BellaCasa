import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { CategoriaService } from './categoria.service';
import { Categoria } from './categoria.model';

@Component({
  selector: 'categoria-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './categoria-list.component.html',
  styleUrls: ['./categoria-list.component.css']
})
export class CategoriaListComponent {
  categorias: Categoria[] = [];
  loading = false;
  error?: string;

  constructor(private service: CategoriaService, private router: Router) {
    this.load();
  }

  load() {
    this.loading = true;
    this.service.listar().subscribe({
      next: (data) => { this.categorias = data; this.loading = false; },
      error: (err) => { this.error = err?.message ?? 'Erro ao listar'; this.loading = false; }
    });
  }

  novo() { this.router.navigate(['/categorias/novo']); }
  editar(id?: number) { if (id) this.router.navigate(['/categorias/editar', id]); }
  detalhes(id?: number) { if (id) this.router.navigate(['/categorias/detalhes', id]); }

  deletar(id?: number) {
    if (!id) return;
    if (!confirm('Deseja deletar esta categoria?')) return;
    this.service.deletar(id).subscribe({
      next: () => this.load(),
      error: (err) => this.error = err?.message ?? 'Erro ao deletar'
    });
  }
}
