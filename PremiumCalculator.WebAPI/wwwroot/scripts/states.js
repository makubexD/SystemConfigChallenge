function loadStates() {
    $("#state").autocomplete({
        minLength: 2,
        source: function (request, response) {
            response(
                $.map(stateList, function (obj, key) {
                    var name = obj.name.toUpperCase();

                    if (name.indexOf(request.term.toUpperCase()) != -1) {
                        return {
                            label: obj.name, // Label for Display
                            value: obj.abbreviation // Value
                        };
                    } else {
                        return null;
                    }
                })
            );
        },
        focus: function (event, ui) {
            event.preventDefault();
        },
        // Once a value in the drop down list is selected, do the following:
        select: function (event, ui) {
            // Prevent value from being put in the input:
            this.value = ui.item.label;
            // Set the next input's value to the "value" of the item.
            $(this)
                .next("input")
                .val(ui.item.value);
            validateForm();
            event.preventDefault();
            // place the person.given_name value into the textfield called 'select_origin'...
            // $("#state").val(ui.item.label);
            // ... any other tasks (like setting Hidden Fields) go here...
        }
    });
}

loadStates();
