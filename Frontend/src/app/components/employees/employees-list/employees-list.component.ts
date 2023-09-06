import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {

  employees: Employee[] = [];
  pageNumber: number = 1;
  maxPages: number = 0;

  constructor(private employeeService: EmployeesService) { }
  ngOnInit(): void {
    this.callAPI();
  }

  pageNumberChange(dir: number) {
    if (this.pageNumber + dir < 1 || this.pageNumber + dir > this.maxPages) return
    this.pageNumber += dir;
    this.callAPI();
  }

  callAPI() {
    this.employeeService.getEmployees(this.pageNumber).subscribe({
      next: (res) => {
        this.employees = res.data as Employee[];
        this.maxPages = Math.ceil(res.totalCount / 10);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}
