/*!
* Start Bootstrap - Creative v7.0.5 (https://startbootstrap.com/theme/creative)
* Copyright 2013-2021 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-creative/blob/master/LICENSE)
*/

//const { request } = require('http');

//
// Scripts
// 



//jQuery Doc Load Ready Evt Listener
$(document).ready( () => {
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

    //Use Discord.js to embed pfp and other functionalities
    const discord = require('discord.js');

    const owner = new discord.User();
    const admin = new discord.User();

    const client = new discord.Client();

    const server = client.guilds.get("688917645139116290");
    const role = server.roles.cache.find(role => role.name === 'Sandwich Overlords');

    console.log(role.name);

    owner.id = '666065974650470431';
    admin.id = '275031750915391491';

    console.log(owner.username);

    //require(['discord.js'], (require) => {

    //});



});
