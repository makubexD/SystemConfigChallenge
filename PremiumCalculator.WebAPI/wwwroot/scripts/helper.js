//// $( "#dateOfBirth" ).datepicker({
//// 	//appendText: "dd-mm-yyyy"
//// 	dateFormat: "dd-mm-yy"
////   });

////TODO: FIX
//$("#dateOfBirth").datepicker("option", "dateFormat", "dd/mm/yy");
  

function getStateFromAutocomplete() {
	const stateInput = $("#state").val();

	const state = stateList.find(item => item.name === stateInput);

	return (state && state.abbreviation) || "";
}

function getDateOfBirth() {	
	const dateOfBirthInput = $("#dateOfBirth").val();

	return new Date(dateOfBirthInput);
}

function getAge() {
	return $("#age").val();
}

function clear() {
	$("#premium").val("");
	$("#annually").val("");
	$("#monthly").val("");
	$("#listError").html("");
	$("#frequencies").prop("selectedIndex", 0);
	$("button.button").prop("disabled", true);
	$("#frequencies").prop("disabled", true);
}

function showError(text) {
	$("#textError").html(text);
}

function calculateAge() {
	const dateOfBirth = getDateOfBirth();
	if (!dateOfBirth) {
		$("#age").val("");
		validateForm();

		return void 0;
	}

	const today = new Date();
	const age = Math.floor(
		(today - dateOfBirth) / (365.25 * 24 * 60 * 60 * 1000)
	);

	$("#age").val(age);
	validateForm();
}

function validateForm() {
	const dateOfBirthInput = getDateOfBirth();
	const stateInput = getStateFromAutocomplete();
	const age = getAge() > 0;

	if (!dateOfBirthInput) {
		showError("Select a valid date.");
		clear();

		return void 0;
	}

	if (!stateInput) {
		showError("Select a valid state.");
		clear();

		return void 0;
	}

	if (!age) {
		showError("Age must be greater than 0.");
		clear();

		return void 0;
	}

	const isValid = dateOfBirthInput && stateInput && age;
	$("button.button").prop("disabled", !isValid);
	showError("");
}

function getParams() {
	return {
		dateOfBirth: getDateOfBirth().toLocaleDateString(),
		state: getStateFromAutocomplete(),
		age: getAge()
	};
}
