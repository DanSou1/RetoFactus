
function toggleNameFields()
{
    const type = document.getElementById('legal_organization_id').value;
    const naturalPerson = document.getElementById('naturalNameField');
    const juridicalPerson = document.getElementById('juridicaNameField');
    const identification = document.getElementById('identification');
    const identification_id = document.getElementById('identification_id');
    switch (type) {
        case "1":
            naturalPerson.style.display = "block";
            juridicalPerson.style.display = "none";
            identification.value = 3;
            identification.disabled = false;
            break;
        case "2":
            naturalPerson.style.display = "none";
            juridicalPerson.style.display = "block";
            identification.value = 6;
            identification.disabled = true;
            identification_id.setAttribute("maxlength", "9")
            break;

        default:
            naturalPerson.style.display = "none";
            juridicalPerson.style.display = "none";
            identification.disabled = false;
            identification.removeAttribute("maxlength", "12");
            break;
    }
}