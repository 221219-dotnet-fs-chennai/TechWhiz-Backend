using System;
using Xunit;
using AutoFixture;
using Moq;
using FluentAssertions;
using Patient_Logic;
using Services.Controllers;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Patient_Test
{
    public class PatientConstollerTesting
    {
        private readonly IFixture _fixture;
        private readonly Mock<IPatientLogic> _patientLogic;
        private readonly PatientController _controller;

        public PatientConstollerTesting()
        {
            _fixture = new Fixture();
            _patientLogic = _fixture.Freeze<Mock<IPatientLogic>>();
            _controller = new PatientController(_patientLogic.Object);

        }

        [Fact]
        public void Test1()
        {
            var Patients = _fixture.Create<IEnumerable<Patient>>();
            _patientLogic.Setup(x => x.GetPatients()).Returns(Patients);

            var res = _controller.Get();

            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(Patients.GetType());
            _patientLogic.Verify(x => x.GetPatients(), Times.AtLeastOnce());

        }
        [Fact]
        public void Test1Details()
        {

            List<Patient> Patients = null;
            _patientLogic.Setup(x => x.GetPatients()).Returns(Patients);

            var res = _controller.Get();

            res.Should().BeAssignableTo<BadRequestResult>();

            _patientLogic.Verify(x => x.GetPatients(), Times.AtLeastOnce());

        }

        [Fact]
        public void Test2()
        {
            var Pateints = _fixture.Create<Patient>();
            var id = _fixture.Create<Guid>();
            _patientLogic.Setup(x => x.GetPatientById(id)).Returns(Pateints);
            var res = _controller.Get(id);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(Pateints.GetType());
            _patientLogic.Verify(x => x.GetPatientById(id), Times.AtLeastOnce());
        }
        [Fact]
        public void Test2Details()
        {
            List<Patient> Patients = null;
            var id = _fixture.Create<Guid>();
            _patientLogic.Setup(x => x.GetPatientById(id)).Throws(new Exception("Went Worng"));
            var res = _controller.Get(id);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.GetPatientById(id), Times.AtLeastOnce());

        }

        [Fact]
        public void Post_Test()
        {
            var req = _fixture.Create<Patient>();

            _patientLogic.Setup(x => x.AddPatient(req)).Returns(req);

            var result = _controller.RegisterPat(req);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _patientLogic.Verify(x => x.AddPatient(req), Times.AtLeastOnce());

        }
        [Fact]
        public void Post_TestNull()
        {
            var req = _fixture.Create<Patient>();

            _patientLogic.Setup(x => x.AddPatient(req));

            var result = _controller.RegisterPat(req);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.AddPatient(req), Times.AtLeastOnce());

        }
        [Fact]
        public void Put_Test()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.UpdatePatient(email, patient)).Returns(patient);
            var res = _controller.Update(email, patient);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(patient.GetType());
            _patientLogic.Verify(x => x.UpdatePatient(email, patient), Times.AtLeastOnce());
        }
        [Fact]
        public void Put_TestDetails()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.UpdatePatient(email, patient)).Throws(new Exception("Something went wrong"));
            var res = _controller.Update(email, patient);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.UpdatePatient(email, patient), Times.AtLeastOnce());
        }
        [Fact]
        public void delete_Test()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.DeletePatient(email)).Returns(patient);
            var res = _controller.Delete(email);
            res.Should().NotBeNull();
            res.Should().BeAssignableTo<OkObjectResult>();
            res.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(patient.GetType());
            _patientLogic.Verify(x => x.DeletePatient(email), Times.AtLeastOnce());
        }
        [Fact]
        public void delete_TestDetails()
        {
            var patient = _fixture.Create<Patient>();
            var email = _fixture.Create<string>();
            _patientLogic.Setup(x => x.DeletePatient(email)).Throws(new Exception("Something went Worng"));
            var res = _controller.Delete(email);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _patientLogic.Verify(x => x.DeletePatient(email), Times.AtLeastOnce());
        }

    }
}
