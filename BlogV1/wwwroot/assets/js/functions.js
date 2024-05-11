//jQuery( document ).ready(function() {

//    $(window).scroll(function(){
//    $('.topnav').toggleClass('scrollednav py-0', $(this).scrollTop() > 50);
//    });

//});

//alert("functions.js"); control!
document.addEventListener("DOMContentLoaded", _ => {
    const topNav = document.getElementsByClassName("topnav")[0];
    if (topNav) {
        window.onscroll = () => {
            if (window.scrollY > 50) {
                // add these class scrollednav py-0
                topNav.classList.add('scrollednav', 'py-0')
            }
            else {
                // remove these classes scrollednav py-0
                topNav.classList.remove('scrollednav', 'py-0')
            }
        };
    }
});

function toggleMenu(e) {
    e.target.classList.toggle('collapsed');
    document.getElementById('top-navbar-menu-wrapper').classList.toggle('show');
}