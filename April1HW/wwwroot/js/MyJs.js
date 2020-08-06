$(() => {
    let count = 0;
    $("#my-btn").on('click', function () {
        $("#my-form").append(`<input type="text" name="peoples[${count}].FirstName" />`);
        $("#my-form").append(`<input type="text" name="peoples[${count}].LastName" />`);
        $("#my-form").append(`<input type="text" name="peoples[${count}].Age" />`);

        count++;
    })
})