const { src, dest, watch } = require("gulp");
const cleanCSS = require("gulp-clean-css");
const rename = require("gulp-rename");

const minifyCSS = () => {
    return src("wwwroot/css/styles/*.css")
        .pipe(cleanCSS())
        .pipe(rename({ extname: ".min.css" }))
        .pipe(dest("wwwroot/css/"));
}

const defaultTask = () => {
    watch("wwwroot/css/styles/*.css", minifyCSS);
}

exports.default = defaultTask;
exports.minifyCSS = minifyCSS;