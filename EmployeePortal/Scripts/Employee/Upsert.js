function isNumberKey(e) {
    if (e.keyCode >= 48 && e.keyCode <= 57)
        return true;
    return false;
}
function isTextKey(e) {
if ((e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 97 && e.keyCode <= 122) || e.keyCode === 32) {
        return true;
    }
    return false;
}
function openDeletePopup(title, actionText, cancleActionText, empId) {
    $('#commonPopup .modal-body .modal-body-content').hide();
    $('.modal .modal-title').text(title);
    $('.modal .modal-footer .btn-secondary').text(cancleActionText);
    $('.modal .modal-footer .btn-primary').text(actionText).attr('onclick', `DeleteEmp(${empId})`);
    $('#deleteModal').show();
    var deleteDv = $('#deleteModal');
    $('#commonPopup .modal-body').append(deleteDv);
    $('#commonPopup').modal('show');
}
function DeleteEmp(empId) {
    $.ajax({
        url: `/employee/delete/${empId}`,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            console.log('Success:', response);
            $('#commonPopup').modal('hide');
            showToast('Success', 'Entry deleted successfully!');

            setTimeout(function () {
                window.location.href = '/employee/index';
            }, 1000);
        },
        error: function (status, error) {
            console.log('Error:', status, error);
        }
    });
}
function showToast(title, message) {
    $('#commonToaster .toast-body').text(message);
    $('#commonToaster').addClass('text-bg-success');
    const toastElement = document.getElementById('commonToaster');
    const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastElement);
    toastBootstrap.show();
}


