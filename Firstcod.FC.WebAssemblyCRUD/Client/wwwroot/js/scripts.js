window.Service = {
    alert: function (id, helpers) {

        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        })

        swalWithBootstrapButtons.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.value) {
                swalWithBootstrapButtons.fire('Deleted!', 'Your file has been deleted.', 'success');

                // javascript to c#.. call method --- static method
                //DotNet.invokeMethodAsync("Firstcod.FC.WebAssemblyCRUD.Client", "DeleteMethod", id);

                // component instance > helpers
                helpers.invokeMethodAsync("DeleteMethod", id);
            }
            else if (result.dismiss === Swal.DismissReason.cancel) {
                swalWithBootstrapButtons.fire('Cancelled', 'Your imaginary file is safe :)', 'error')
            }
        })
    }
}