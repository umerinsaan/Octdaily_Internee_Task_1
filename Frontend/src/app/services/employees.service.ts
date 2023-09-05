import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { baseApiUrl } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(baseApiUrl + 'api/employees');
  }
}
