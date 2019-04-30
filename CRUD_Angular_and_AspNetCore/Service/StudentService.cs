using CRUD_Angular_and_AspNetCore.DatabaseContext;
using CRUD_Angular_and_AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_Angular_and_AspNetCore.Service
{
	public class StudentService : IStudentService
	{
		private IServiceProvider serviceProvider { get; }
		private ApplicationDbContext context => serviceProvider.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
		public StudentService(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}
		public bool CreateStudent(StudentEntity entity)
		{
			context.students.Add(entity);
			return context.SaveChanges() > 0 ? true : false;
		}

		public List<StudentEntity> GeadAllStudents()
		{
			var v = context.students.ToList();
			return v;
		}

		public StudentEntity GetStudentById(int id)
		{
			return context.students.Where(x => x.Id == id).FirstOrDefault();
		}

		public bool UpdateStudent(StudentEntity entity)
		{
			StudentEntity existingStudent = context.students.Where(x => x.Id == entity.Id).FirstOrDefault();
			if (existingStudent.Id > 0)
			{
				existingStudent.City = entity.City;
				existingStudent.Email = entity.Email;
				existingStudent.LastName = entity.LastName;
				existingStudent.FirstName = entity.FirstName;
				existingStudent.PhoneNumber = entity.PhoneNumber;
				existingStudent.EnrolledDate = entity.EnrolledDate;
			}
			context.Entry(existingStudent).State = EntityState.Modified;
			return context.SaveChanges() > 0 ? true : false;
		}

		public bool DeleteStudent(int id)
		{
			StudentEntity student = context.students.Where(x => x.Id == id).FirstOrDefault();
			context.students.Remove(student);
			return context.SaveChanges() == 1 ? true : false;
		}
	}
}
