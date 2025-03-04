import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { CommonModule } from '@angular/common'; 
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: 'login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    console.log("Login butonuna basıldı."); 
    console.log("Girilen kullanıcı adı:", this.username);
    console.log("Girilen şifre:", this.password);
  
    this.authService.login(this.username, this.password).subscribe({
      next: (response) => {
        console.log("Sunucudan dönen yanıt:", response); 
  
        if (response.token) {
          console.log("Giriş başarılı, yönlendiriliyor...");
          localStorage.setItem('token', response.token); 
          this.router.navigate(['/profile']);
        } else {
          console.log("Giriş başarısız! Yanıt:", response);
          this.errorMessage = 'Giriş başarısız. Lütfen bilgilerinizi kontrol edin.';
        }
      },
      error: (err) => {
        console.error("Sunucu hatası:", err); 
        this.errorMessage = 'Lütfen bilgilerinizi kontrol ediniz.';
      }
    });
  }  
}
