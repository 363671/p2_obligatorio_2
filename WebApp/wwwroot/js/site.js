// toggle theme
const toggleThemeButton = document.querySelector(".toggle-theme");

toggleThemeButton.addEventListener("click", () => {
    document.body.classList.toggle("light");
});

// prevent default behavior of all links
document.querySelectorAll('a[href="#"]').forEach((a) => {
    a.addEventListener("click", (e) => e.preventDefault());
});

// links hover
const linksTab = document.querySelectorAll(".links-tab");
const tabActive = document.querySelector(".links-tab-active");
let currentTab = 0;

const move = (target, ac) => {
    const { clientHeight, clientWidth, offsetLeft, offsetTop } = target;
    tabActive.style.left = `${offsetLeft}px`;
    tabActive.style.top = `${offsetTop}px`;
    tabActive.style.width = `${clientWidth}px`;
    tabActive.style.height = `${clientHeight}px`;
    currentTab = ac;
};
move(linksTab[0], 0);

linksTab.forEach((el, index) => {
    el.addEventListener("mouseover", ({ target }) => {
        move(target, index);
    });
});
