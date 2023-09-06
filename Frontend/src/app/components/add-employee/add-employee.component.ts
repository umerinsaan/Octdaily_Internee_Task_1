import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {

  constructor(private employeesService: EmployeesService, private router: Router) { }

  employee: Employee = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    email: '',
    phone: '',
    salary: null,
    department: ''
  }

  addEmployee(): void {
    this.employeesService.postEmployee(this.employee).subscribe({
      next: (res: Employee) => {
        this.router.navigate(['']);
      }
    });
  }
}
