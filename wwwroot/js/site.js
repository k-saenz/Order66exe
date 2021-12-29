

//jQuery Doc Load Ready Evt Listener
$(document).ready(() => {
    // Navbar shrink function
    var navbarShrink = function () {
        const navbarCollapsible = document.body.querySelector('#mainNav');
        if (!navbarCollapsible) {
            return;
        }
        if (window.scrollY === 0) {
            navbarCollapsible.classList.remove('navbar-shrink')
        } else {
            navbarCollapsible.classList.add('navbar-shrink')
        }

    };

    // Shrink the navbar 
    navbarShrink();

    // Shrink the navbar when page is scrolled
    document.addEventListener('scroll', navbarShrink);

    // Activate Bootstrap scrollspy on the main nav element
    const mainNav = document.body.querySelector('#mainNav');
    if (mainNav) {
        var scrollSpy = new bootstrap.ScrollSpy(document.body, {
            target: '#mainNav',
            //offset: 74,
        });
    };

    // Collapse responsive navbar when toggler is visible
    const navbarToggler = document.body.querySelector('.navbar-toggler');
    const responsiveNavItems = [].slice.call(
        document.querySelectorAll('#navbarResponsive .nav-link')
    );
    responsiveNavItems.map(function (responsiveNavItem) {
        responsiveNavItem.addEventListener('click', () => {
            if (window.getComputedStyle(navbarToggler).display !== 'none') {
                navbarToggler.click();
            }
        });
    });

    // Activate SimpleLightbox plugin for portfolio items
    new SimpleLightbox({
        elements: '#portfolio a.portfolio-box'
    });

    //Change header text in Info page when accordion element is expanded
    //Change back to 'Rules and Stuff' when collapsed
    let rulesAndStuff = $("#InfoAccordian .accordion-item h2").click( evt => {
        let rulesBtn = $(evt.target).text();
        let generalRules = "These rules apply to any part of the server, whether that be voice or text channel";
        let voiceRules = "In addition to the General Rules, follow these when joining a Voice Channel";
        let roles = "Current Roles that users can have in our server";

        if (!$(evt.target).hasClass("collapsed")) {
            $("#RulesAndStuffHeader").text(rulesBtn);
            $("#RulesAndStuffInfo").text();
        } else {
            $("#RulesAndStuffHeader").text("Rules and Stuff");
        }
    });
});