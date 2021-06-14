const type = document.getElementById('visit-type');
const patient = document.getElementById('patient-appointment');

if (type.value == 2) {
    patient.classList.add('d-none');
}