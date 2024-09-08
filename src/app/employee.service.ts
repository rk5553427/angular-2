import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from './employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpCliet:HttpClient) { }
  getEmployee():Observable<any>
  {
    return this.httpCliet.get<any>("https://localhost:7194/api/employee");
  }
  saveEmployee(employee:Employee):Observable<any>
  {
    return this.httpCliet.post<any>("https://localhost:7194/api/employee",employee);
  }
  updateEmployee(employee:Employee):Observable<Employee>
  {
    return this.httpCliet.put<Employee>("https://localhost:7194/api/employee", employee);
  }
  deleteEmployee(id:number):Observable<any>
  {
    return this.httpCliet.delete<any>("https://localhost:7194/api/employee/" + id);
  }
}
