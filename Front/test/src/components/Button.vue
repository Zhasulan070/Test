<template>
  <component
      :class="['btn', `btn--${variant}`, buttonClass]"
      v-bind="$attrs"
      v-on="$listeners"
      :is="tag"
  >
    <slot>Найти</slot>
  </component>
</template>

<script>
export default {
  name: "Button",
  props: {
    variant: {
      type: String,
      default: "default",
      validator: function (value) {
        return (
            [
              "default",
            ].indexOf(value) !== -1
        );
      },
    },
    buttonClass: {
      type: String,
      default: "",
    },
    tag: {
      type: String,
      default: "button",
    },
  },
}
</script>

<style lang="scss" scoped>
.btn {
  border-radius: 2px;
  font-size: 14px;
  line-height: 22px;
  border: none;
  outline: none;
  cursor: pointer;
  transition: 0.3s all;
  display: flex;
  justify-content: center;
  align-items: center;

  &:disabled {
    cursor: not-allowed;
  }

  &--cancel {
    background: white;
    color: #9da3ac;
    min-width: 121px;
    height: 48px;
    padding: 16px 36px;
    border: 1px solid #9da3ac80;
  }

  &--default {
    background: #53C8E1;
    color: #333333;
    min-width: 121px;
    width: 100%;
    height: 48px;
    padding: 16px 36px;

    &:hover {
      background: #77d4e9;
    }

    &:active {
      background: #30aec4;
    }
  }
}

</style>
