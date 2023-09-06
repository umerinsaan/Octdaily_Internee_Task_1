import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { baseApiUrl } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.model';
import { HtmlParser } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) { }

  getEmployees(pgNumber: number): Observable<any> {
    return this.http.get<Employee[]>(baseApiUrl + 'api/employees?page=' + pgNumber + '&pageSize=10');
  }

  postEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(baseApiUrl + 'api/employees', employee);
  }

  getEmployee(id: string): Observable<Employee> {
    return this.http.get<Employee>(baseApiUrl + 'api/employees/' + id);
  }

  updateEmployee(id: string, employee: Employee): Observable<Employee> {
    return this.http.put<Employee>(baseApiUrl + 'api/employees/' + id, employee);
  }

  deleteEmployee(id: string): Observable<Employee> {
    return this.http.delete<Employee>(baseApiUrl + 'api/employees/' + id);
  }
}
