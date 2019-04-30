using CRUD_Angular_and_AspNetCore.Entity;
using CRUD_Angular_and_AspNetCore.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CRUD_Angular_and_AspNetCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private IServiceProvider service;
		private IStudentService studentService => service.GetService(typeof(IStudentService)) as IStudentService;

		public StudentController(IServiceProvider service)
		{
			this.service = service;
		}

		[Route("create-student")]
		public bool CreateStudent(StudentEntity student)
		{
			return studentService.CreateStudent(student);
		}

		[Route("get-student-byId")]
		public StudentEntity GetStudentsById([FromQuery(Name = "id")] int id)
		{
			return studentService.GetStudentById(id);
		}

		[Route("get-all-students")]
		public List<StudentEntity> GetAllStudents()
		{
			return studentService.GeadAllStudents();
		}

		[Route("update-student")]
		public bool UpdateStudent([FromBody] StudentEntity student)
		{
			return studentService.UpdateStudent(student);
		}

		[Route("delete-student")]
		public bool DeleteStudent([FromQuery(Name = "id")] int id)
		{
			return studentService.DeleteStudent(id);
		}
	}
}
