using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Domain.Tests
{
    public class ConsulationTests
    {
        [Fact]
        public void Consultation_should_be_open()
        {
            var cosutantion = new Consultation(Guid.NewGuid());
            Assert.True(cosutantion.Status == ConsultationStatus.Open);
        }
        [Fact]
        public void Consultation_should_not_have_ended_timestamp()
        {
            var cosutantion = new Consultation(Guid.NewGuid());
            Assert.Null(cosutantion.EndedAt);
        }
        [Fact]
        public void Consultation_should_not_end_when_missing_data()
        {
            var cosutantion = new Consultation(Guid.NewGuid());
            Assert.Throws<InvalidOperationException>(cosutantion.End);
        }
        [Fact]
        public void Consultation_should_end_with_complete_data()
        {
            var cosutantion = new Consultation(Guid.NewGuid());
            cosutantion.SetTreatment("treatment");
            cosutantion.SetDiagnosis("diagnosis");
            cosutantion.SetWheight(18.5m);
            cosutantion.End();
            Assert.True(cosutantion.Status == ConsultationStatus.Closed);
        }
        [Fact]
        public void Consultation_should_not_allow_weight_updates_when_closed()
        {
            var cosutantion = new Consultation(Guid.NewGuid());
            cosutantion.SetTreatment("treatment");
            cosutantion.SetDiagnosis("diagnosis");
            cosutantion.SetWheight(19.8m);
            cosutantion.End();
            Assert.Throws<InvalidOperationException>(() => cosutantion.SetWheight(19.8m));
        }
        [Fact]
        public void Consultation_should_not_allow_treatment_updates_when_closed()
        {
            var cosutantion = new Consultation(Guid.NewGuid());
            cosutantion.SetDiagnosis("diagnosis");
            cosutantion.SetTreatment("dípirona de 8 em 8");
            cosutantion.SetWheight(18.5m);
            cosutantion.End();
            Assert.Throws<InvalidOperationException>(() => cosutantion.SetTreatment("dípirona de 8 em 8"));
        }
        [Fact]
        public void Consultation_should_not_allow_diagnosis_updates_when_closed()
        {
            var cosutantion = new Consultation(Guid.NewGuid());
            cosutantion.SetTreatment("treatment");
            cosutantion.SetDiagnosis("diagnosis");
            cosutantion.SetWheight(18.5m);
            cosutantion.End();

            Assert.Throws<InvalidOperationException>(() => cosutantion.SetDiagnosis("Dor de cabeça"));
        }

        [Fact]
        public void Consultation_should_administer_drug()
        {
            var drugId = new DrugId(Guid.NewGuid());
            var cosutantion = new Consultation(Guid.NewGuid());
            cosutantion.AdministerDrug(drugId, new Dose(1, UnitOfMeasure.tablet));
            Assert.True(cosutantion.AdministrateredDrugs.Count == 1);
            Assert.True(cosutantion.AdministrateredDrugs.First().DrugId == drugId);
        }

        [Fact]
        public void Consultation_should_register_vitalsigns()
        {
            var cosutantion = new Consultation(Guid.NewGuid());
            IEnumerable<VitalSigns> vitalSigns = new List<VitalSigns>{new VitalSigns(36.5m, 80, 20)};
            cosutantion.RegisterVitalSigns(vitalSigns);
            Assert.True(cosutantion.VitalSignsReadings.Count == 1);
            Assert.True(cosutantion.VitalSignsReadings.First() == vitalSigns.First());
        }
    }
}