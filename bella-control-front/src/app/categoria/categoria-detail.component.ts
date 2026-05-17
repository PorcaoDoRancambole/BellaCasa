import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriaService } from './categoria.service';
import { Categoria } from './categoria.model';

@Component({
  selector: 'categoria-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './categoria-detail.component.html',
  styleUrls: ['./categoria-detail.component.css']
})
export class CategoriaDetailComponent {
  categoria?: Categoria;
  loading = true;
  error?: string;

  constructor(private route: ActivatedRoute, private service: CategoriaService, public router: Router) {
    const idParam = this.route.snapshot.paramMap.get('id');
    const id = idParam ? Number(idParam) : null;
    if (id) {
      this.service.buscar(id).subscribe({
        next: (c) => { this.categoria = c; this.loading = false; },
        error: (err) => { this.error = err?.message ?? 'Erro'; this.loading = false; }
      });
    } else {
      this.error = 'ID inválido';
      this.loading = false;
    }
  }
}
