$(function () {
    $(".datepicker").datetimepicker(
        {
            format: 'L'
        }
    );


});

$('#UploadImage').click(function () {
    //alert('clickeed');
    UploadClickEvent();
});
$('.upload-photo').click(function () {
    //alert('clickeed');
    UploadClickEvent();
   
});
function UploadClickEvent() {
    $('#InputUploadFile').trigger('click');
}

$('#InputUploadFile').change(function () {

    var Files = this.files;
    if (Files && Files[0]) {
        var fileread = new FileReader();
        fileread.readAsDataURL(Files[0]);
        fileread.onload = function (x) {
            var image = new Image;
            image.src = x.target.result;
            image.onload = function () {
                var width = this.width;
                var height = this.heigth;
                var type = Files[0].type;
                var filesize = Math.round( Files[0].size / 1024);
          //  alert('width:' + width + 'and Heigth:' + height + ' type:' + Files[0].type+' type:' + (Files[0].size)/1024);

                if ((filesize < 800) && (type == "image/jpeg" || type == "image/jpg" || type == "image/png"))
                {
                    $('#UploadImage').attr('src', x.target.result);
                    $('.description').text('');
                }
                else {
                    $('.description').text('Your image size should be less than 800 KB' + ' its' + filesize + ' KB');
                    $('.description').addClass('red');
                }

            }

            
        }

    }
});

$('.remove-photo').click(function () {
    $('#UploadImage').attr('src', "/images/no-image.jpg");
    $('#ImagePath').val(null);
});

