using CICDProject.Controllers;
using CICDProject.Data;
using CICDProject.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDApi.UnitTests.Controller
{
    [TestFixture]
    public class StudentControllerTests
    {
        private StudentController _controller;

        [SetUp]
        public void Setup()
        {
            StudentRepository.Reset();   // Reset dummy data before every test
            _controller = new StudentController();
        }

        [Test]
        public void GetAll_ShouldReturnOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult!.Value.Should().NotBeNull();
        }

        [Test]
        public void Get_WhenStudentExists_ShouldReturnOk()
        {
            // Act
            var result = _controller.Get(1);

            // Assert
            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            var student = okResult!.Value as Student;

            student.Should().NotBeNull();
            student!.Id.Should().Be(1);
        }

        [Test]
        public void Get_WhenStudentDoesNotExist_ShouldReturnNotFound()
        {
            // Act
            var result = _controller.Get(100);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Test]
        public void Create_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var student = new Student
            {
                Name = "Puneet",
                Age = 42,
                City = "Mumbai"
            };

            // Act
            var result = _controller.Create(student);

            // Assert
            result.Should().BeOfType<CreatedAtActionResult>();

            var created = result as CreatedAtActionResult;
            var createdStudent = created!.Value as Student;

            createdStudent.Should().NotBeNull();
            createdStudent!.Name.Should().Be("Puneet");
        }

        [Test]
        public void Update_WhenStudentExists_ShouldReturnOk()
        {
            // Arrange
            var student = new Student
            {
                Name = "Updated Name",
                Age = 25,
                City = "Pune"
            };

            // Act
            var result = _controller.Update(1, student);

            // Assert
            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            var updatedStudent = okResult!.Value as Student;

            updatedStudent!.Name.Should().Be("Updated Name");
            updatedStudent.City.Should().Be("Pune");
        }

        [Test]
        public void Update_WhenStudentDoesNotExist_ShouldReturnNotFound()
        {
            // Arrange
            var student = new Student
            {
                Name = "Test",
                Age = 30,
                City = "Delhi"
            };

            // Act
            var result = _controller.Update(999, student);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Test]
        public void Delete_WhenStudentExists_ShouldReturnNoContent()
        {
            // Act
            var result = _controller.Delete(1);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public void Delete_WhenStudentDoesNotExist_ShouldReturnNotFound()
        {
            // Act
            var result = _controller.Delete(999);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
