<script>
    $(document).ready(function () {
        // Open the modal when the "Create New" button is clicked
        $("#openCreateModal").click(function () {
            $("#createModal").modal("show");
        });

    // Submit form using AJAX
    $("#createStudentForm").submit(function (e) {
        e.preventDefault();

    $.ajax({
        url: $(this).attr("action"),
    type: $(this).attr("method"),
    data: $(this).serialize(),
    success: function (data) {
                    // Check if the form submission was successful
                    if (data.success) {
        // Close the modal
        $("#createModal").modal("hide");

    // Redirect to the Index page after successful creation
    window.location.href = '/Students/Index'; // Change the URL if needed
                    } else {
        // Handle errors if needed
    }
                },
    error: function (data) {
        // Handle errors if needed
    }
            });
        });

    // Close the modal when the "Close" button is clicked
    $("#closeCreateModal").click(function () {
        $("#createModal").modal("hide");
        });
    });
</script>