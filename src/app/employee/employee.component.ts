import { Component } from '@angular/core';
import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';
import { setThrowInvalidWriteToSignalError } from '@angular/core/primitives/signals';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.scss'
})
export class EmployeeComponent {
  employeeList:Employee[]=[]; 
  newEmployee:Employee=new Employee();
  editEmployee:Employee=new Employee();
  constructor(private employeeService:EmployeeService){}
  ngOnInit()
  {
    this.getAll();
  }
  getAll()
  {
    this.employeeService.getEmployee().subscribe(
      (response)=>{
        this.employeeList=response;
        console.log(this.employeeList);
      },
      (error)=>{
        console.log('unable to fatch data')
      }
    );
  }
saveClick()
{
  if(this.newEmployee.name="") return;
  if(this.newEmployee.address="") return;
  if(this.newEmployee.salary=0) return;
  this.employeeService.saveEmployee(this.newEmployee).subscribe(
    (response)=>{
      alert('Data Saved');
      this.getAll();
      this.clearRec();
    },
    (error)=>{
      console.log('Data not Saved');
    }                                 
   );
}
clearRec(){
  this.newEmployee.name=="";
  this.newEmployee.address=="";

  this.newEmployee.salary==0;
}

editClick(emp:any){
this.editEmployee=emp;
}
updateClick(){
  this.employeeService.updateEmployee(this.editEmployee).subscribe(
    (response)=>{
      alert('data saved');
      this.getAll();
    },
    (error)=>{
      console.log('data not update');
    }
  );
}
deleteClick(id:number){
let ans=window.confirm('Want to delete Data');
if(!ans) return;
this.employeeService.deleteEmployee(id).subscribe(
  (response)=>{
    alert('Data Deleted !!!');
  },
  (error)=>{
    console.log('data Deleted');
  }
);
}
}

