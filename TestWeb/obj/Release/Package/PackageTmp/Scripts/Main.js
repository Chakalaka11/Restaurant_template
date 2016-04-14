
$(document).ready(function () {
    $('.parallax-window').parallax({ imageSrc: '../../Content/Pictures/Paralax_image.jpg' });
});


$(document).ready(function () {
    $('#MainCarousel').on('slide.bs.carousel', function () {
        $('.item').toggleClass('white');
    })
});
$(document).ready(function () {
    $('#MainCarousel').on('slid.bs.carousel', function () {

    })
});