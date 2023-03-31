using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;



namespace BussinessLogic
{
    public static class Mapper
    {
      
        public static Models.Appointment Map(DataEntities.Entities.Appointment a)
        {
            return new Models.Appointment()
            {
                AppointmentId=a.AppointmentId,
                PatientId=a.PatientId,
                DoctorId=a.DoctorId,
                Date=a.Date,
                DoctorName=a.DoctorName,
                Concerns=a.Concerns,
                Status=a.Status
                

            };
        }

        public static IEnumerable<Models.Appointment> Map(IEnumerable<DataEntities.Entities.Appointment> appointments)
        {
            return appointments.Select(Map).ToList();
        }


        public static DataEntities.Entities.Appointment Map(Models.Appointment a)
        {
            return new DataEntities.Entities.Appointment()
            {
                AppointmentId = a.AppointmentId,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Date = a.Date,
                DoctorName = a.DoctorName,
                Concerns = a.Concerns,
                Status = a.Status
            };
        }


        //------------------------------------------------PatientMapper-----------------------------------------------------------------------------

        public static Models.PatientIntialCheckUp Map(DataEntities.Entities.PatientIntialCheckup p)
        {
            return new Models.PatientIntialCheckUp()
            {
               PicId=p.PicId,
               AppointmentId=p.AppointmentId,
               Height=p.Height,
               Weight=p.Weight,
               Temperature=p.Temperature,
               Spo2=p.Spo2,
               BloodPressure=p.BloodPressure,
               SugarLevel=p.SugarLevel,
               AdditionalDetails=p.AdditionalDetails,
               ChechupStatus=p.ChechupStatus


            };
        }

        public static IEnumerable<Models.PatientIntialCheckUp> Map(IEnumerable<DataEntities.Entities.PatientIntialCheckup> patientIntials)
        {
            return patientIntials.Select(Map).ToList();
        }
        public static DataEntities.Entities.PatientIntialCheckup Map(Models.PatientIntialCheckUp p)
        {
            return new DataEntities.Entities.PatientIntialCheckup()
            {
                PicId = p.PicId,
                AppointmentId = p.AppointmentId,
                Height = p.Height,
                Weight = p.Weight,
                Temperature = p.Temperature,
                Spo2 = p.Spo2,
                BloodPressure = p.BloodPressure,
                SugarLevel = p.SugarLevel,
                AdditionalDetails = p.AdditionalDetails,
                ChechupStatus = p.ChechupStatus



            };
        }

    }
}
