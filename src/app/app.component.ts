import { Component } from '@angular/core';
import { RouterOutlet, Router } from '@angular/router'; 
import { AuthService } from './auth.service';
import { CommonModule } from '@angular/common'; 
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from "./shared/sidebar/sidebar.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    RouterOutlet,
    SidebarComponent
  ], 
  templateUrl: 'app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title(title: any) {
    throw new Error('Method not implemented.');
  }
  username: string = '';
  password: string = '';
  errorMessage: string = '';
  message: string = '';
  token: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  getUsername(): string {
    return this.authService.getUsername();
  }

  logout() {
    this.authService.logout();
  }

  isLoginPage(): boolean {
    return this.router.url === '/login';
  }
}