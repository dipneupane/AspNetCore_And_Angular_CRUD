import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrManager } from 'ng6-toastr-notifications';
import { StudentModel } from '../model/student.model';
import { StudentCrudService } from '../service/StudentCRUD.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']

})
export class StudentComponent implements OnInit {
  display: string = null;
  title: string = null;

  togglePopUp: boolean = false;
  studentIdForDelete: number = null;
  student = new StudentModel();
  studentList: StudentModel[] = [];

  constructor(private crudService: StudentCrudService, public toastr: ToastrManager) { }


  ngOnInit() {
    this.display = "list";
    this.title = "Students Listing";

    this.GetAllStudents();
  }

  GetAllStudents() {
    this.crudService.GetAll().subscribe(res => {
      let result = <StudentModel[]>res;
      this.studentList = result;
    });
  }

  GetStudentById(id: number) {
    this.crudService.GetById(id).subscribe(res => {
      let result = <StudentModel>res;
      if (result !== null) {
        this.display = "addNew";
        this.student = result;
      } else {
        this.toastr.errorToastr('Encountered an error.', 'Oops!');
      }
    });
  }


  AddStudent(form: NgForm) {
    this.student = <StudentModel>form.value;
    if (this.student.id > 0)
      return this.UpdateStudent(this.student, form);

    else {
      this.student.id = 0;
      this.crudService.Create(this.student).subscribe(res => {
        let result = <boolean>res;
        if (result) {
          form.reset();
          this.display = "list";
          this.GetAllStudents();
          this.toastr.successToastr('New Student Added.', 'Success!');
        } else {
          this.toastr.errorToastr('Encountered an error.', 'Oops!');
        }
      });
    }
  }

  UpdateStudent(student: StudentModel, form: NgForm) {
    this.crudService.Update(this.student).subscribe(res => {
      let result = <boolean>res;
      if (result) {
        form.reset();
        this.display = "list";
        this.title = "Partner";
        this.GetAllStudents();
        this.toastr.successToastr('Student Information Updated.', 'Success!');
      } else {
        this.toastr.errorToastr('Encountered an error.', 'Oops!');
      }
    });
  }

  ConfirmDelete(id: number) {
    this.togglePopUp = true;
    this.studentIdForDelete = id;
  }

  DeleteStudent() {
    this.crudService.Delete(this.studentIdForDelete).subscribe(res => {
      this.togglePopUp = false;
      let result = <boolean>res;
      if (result) {
        this.GetAllStudents();
        this.toastr.successToastr('Student Information Deleted.', 'Success!');
      } else {
        this.toastr.errorToastr('Encountered an error.', 'Oops!');
      }
    });
  }
}
