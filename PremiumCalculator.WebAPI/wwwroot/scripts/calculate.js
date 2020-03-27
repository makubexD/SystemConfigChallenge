function calculate() {
	const url = `http://localhost:52654/api/calculator/query`;

    clear();

	$.ajax({
		dataType: "text",
		contentType: "application/json",
		responseType: "application/json",
		url,
		data: getParams(),
		success: successCalculate,
		error: errorCalculate
	});
}

function successCalculate(result) {
	if (!result) {
		return void 0;
	}

	const value = JSON.parse(result);
	$("#premium").val(value.premium);
	$("button.button").prop("disabled", false);
	$("#frequencies").prop("disabled", false);
}

function errorCalculate(result) {
	$("#frequencies").prop("disabled", true);

	if (!result.responseText) {
		return void 0;
	}

	try {
		const value = JSON.parse(result.responseText);
		Object.keys(value.errors).forEach(key => {
			let errorCode = `<li>${key}<ul>`;
			value.errors[key].forEach(error => (errorCode += `<li>${error}</li>`));
			errorCode += `</ul></li>`;
			$("#listError").html(errorCode);
		});
	} catch {
		showError(result.responseText);
	}
}

function setFrequencies() {
	const frequency = $("#frequencies").val();
	const premium = $("#premium").val();

	const monthly = 100 * (premium / (12 / frequency));
	const annually = 1200 * (premium * frequency);

	$('#monthly').val(monthly);
	$('#annually').val(annually);
}
