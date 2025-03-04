import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterModule], 
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {
  expandedGroups: { [key: string]: boolean } = {
    sigorta: false,
    sistem: false,
    finans: false
  };
  constructor(private router: Router) {}

  toggleGroup(group: string): void {
    this.expandedGroups[group] = !this.expandedGroups[group];
  }

  isGroupExpanded(group: string): boolean {
    return this.expandedGroups[group];
  }

  isUsersPage(): boolean {
    return this.router.url.includes('/pages/users');
  }  
}
