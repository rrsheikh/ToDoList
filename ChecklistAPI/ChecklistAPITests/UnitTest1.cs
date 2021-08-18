using NUnit.Framework;
using ChecklistAPI;
using ChecklistAPI.Controllers;
using ChecklistAPI.Repository;
using ChecklistAPI.Model;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;
using System.Web.Http;
using System;

namespace ChecklistAPITests
{
    public class Tests
    {
        Mock<IUserTaskRepository> mockRepo;
        ChecklistController controller;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IUserTaskRepository>();
        }

        [Test]
        public void GetChecklist()
        {
            //Arrange
            mockRepo.Setup(x => x.GetChecklist()).Returns(new List < UserTask >());
            controller = new ChecklistController(mockRepo.Object);

            //Act
            IActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkObjectResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(200, contentResult.StatusCode);
        }

        [Test]
        public void AddTaskToChecklist()
        {
            UserTask newTask = new UserTask { Description = "new task", Completed = true };
            IUserTaskRepository userRepo = new UserTaskRepository();
            controller = new ChecklistController(userRepo);

            controller.AddTask(newTask);
            List<UserTask> newTaskList = userRepo.GetChecklist();

            Assert.AreEqual(newTask.Description, newTaskList[newTaskList.Count-1].Description);

        }
    }
}