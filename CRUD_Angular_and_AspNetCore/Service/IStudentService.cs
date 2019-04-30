using CRUD_Angular_and_AspNetCore.Entity;
using System.Collections.Generic;

namespace CRUD_Angular_and_AspNetCore.Service
{
	public interface IStudentService
	{
		bool CreateStudent(StudentEntity entity);
		List<StudentEntity> GeadAllStudents();
		StudentEntity GetStudentById(int id);
		bool UpdateStudent(StudentEntity entity);
		bool DeleteStudent(int id);
	}
}
